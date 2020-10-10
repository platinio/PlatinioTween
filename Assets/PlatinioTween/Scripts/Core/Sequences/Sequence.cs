using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platinio.TweenEngine
{
	public enum PlayMode
	{
		Append,
		Join
	}

	public class Sequence : IRecyclable
	{
		private List<BaseTween> tweenList = new List<BaseTween>();
		private List<TimeEvent> timeEvents = new List<TimeEvent>();
		
		private float timer = 0.0f;
		private BaseTween head = null;
		private List<Command> commandQueue = new List<Command>();
		private int loops = 0;
		private bool ignoreCommands = false;

		public Action OnComplete = null;
		public bool CanRecycle { get; private set; }

		public Sequence()
		{
			CanRecycle = false;
			OnComplete += CheckLoops;
		}

		public void Update(float deltaTime)
		{
			timer += deltaTime;

			for (int n = 0; n < timeEvents.Count ; n++)
			{
				if (timeEvents[n].Time < timer)
				{
					timeEvents[n].Action.Invoke();
					timeEvents.RemoveAt(n);
					n--;
				}
			}

		}

		public void SetOnComplete(Action action)
		{
			OnComplete += action;
		}

		private void CheckLoops()
		{
			if (loops < 0 || loops > 0)
			{
				loops--;
				Reset();
				RunAigan();
			}
		}

		private void RunAigan()
		{
			head = null;
			tweenList.Clear();
			timer = 0.0f;
			OnComplete = null;
			OnComplete += CheckLoops;
			ignoreCommands = true;
			
			for (int n = 0; n < commandQueue.Count; n++)
			{
				commandQueue[n].Execute();
			}

		}

		public void Append(BaseTween tween)
		{
			if (ShouldPlayInmediatly())
			{
				PlayTweenInmediatly(tween);
				head = tween;
				return;
			}
			
			PlayTweenOnComplete(tween, head, PlayMode.Append);
			head = tween;
		}
		
		public void Join(BaseTween tween)
		{
			if (ShouldPlayInmediatly())
			{
				PlayTweenInmediatly(tween);
				return;
			}
			
			PlayTweenOnComplete(tween, GetPenultimate(), PlayMode.Join);
		}

		private void PlayTweenInmediatly(BaseTween tween)
		{
			tweenList.Add(tween);
			tween.SetOnComplete(CheckIfSequenceIsComplete);

			if (!ignoreCommands)
			{
				commandQueue.Add(new AppendTweenCommand(tween, this));
			}
		}

		private void PlayTweenOnComplete(BaseTween tween, BaseTween previousTween, PlayMode playMode)
		{
			//pause the tween until it can actually run
			tween.SetIsPause(true);
			previousTween.SetOnComplete(delegate { RunTween(tween); });
			tweenList.Add(tween);
			tween.SetOnComplete(CheckIfSequenceIsComplete);

			if (!ignoreCommands)
			{
				commandQueue.Add(GetCommand(playMode, tween));
			}
		}

		private Command GetCommand(PlayMode mode, BaseTween tween)
		{
			if (mode == PlayMode.Append)
			{
				return  new AppendTweenCommand(tween, this);
			}
			else
			{
				return new JoinTweenCommand(tween, this);
			}
		}

		private bool ShouldPlayInmediatly()
		{
			return head == null || head.IsComplete;
		}

		private BaseTween GetLastTween()
		{
			return tweenList[tweenList.Count - 1];
		}

		public void SetLoops(int loops)
		{
			if(loops == 0 || loops == 1)
				return;
			
			this.loops = loops - 1;
		}

		public void Append(Action callback)
		{
			if (ShouldPlayInmediatly())
			{
				callback.Invoke();
				return;
			}
			
			head.SetOnComplete(callback);
		}

		public void Join(Action callback)
		{
			if (ShouldPlayInmediatly())
			{
				callback.Invoke();
				return;
			}
			
			GetPenultimate().SetOnComplete(callback);
		}

		public void RunAtTime(Action callback, float time)
		{
			timeEvents.Add(new TimeEvent(callback, time));
		}
		
		public void RunAtTime(BaseTween tween, float time)
		{
			tween.SetIsPause(true);
			timeEvents.Add(new TimeEvent(delegate { RunTween(tween); }, time));
		}

		public void Reset()
		{
			tweenList.Clear();
			timeEvents.Clear();
			timer = 0.0f;
			OnComplete = null;
			CanRecycle = false;
		}

		private void RunTween(BaseTween tween)
		{
			tween.SetIsPause(false);
		}

		private void CheckIfSequenceIsComplete()
		{
			Debug.LogError("checking if sequence is complete");
			foreach (var tween in tweenList)
			{
				if (!tween.IsComplete)
				{
					Debug.LogError("tween is incomplete");
					return;
				}
			}
			
			Debug.LogError("sequence is complete");
			
			//CanRecycle = true;
			
			if(OnComplete != null)
				OnComplete.Invoke();
		}

		private BaseTween GetPenultimate()
		{
			if (tweenList.Count <= 0)
				return null;
			if (tweenList.Count < 2)
				return tweenList[0];

			return tweenList[tweenList.Count - 2];
		}

	}

	public abstract class Command
	{
		protected Sequence sequence;

		protected Command(Sequence sequence)
		{
			this.sequence = sequence;
		}

		public abstract void Execute();
	}

	public class AppendTweenCommand : Command
	{
		public BaseTween tween;

		public AppendTweenCommand(BaseTween tween, Sequence sequence) : base(sequence)
		{
			this.tween = tween;
		}


		public override void Execute()
		{
			tween.ReplayReset();
			TweenPool.activeTweens.Add(tween);
			tween.SetOnComplete(() => tween.IsComplete = true);
			tween.SetOnComplete(() => TweenPool.activeTweens.Remove(tween));
			sequence.Append(tween);
		}
	}
	
	public class JoinTweenCommand : Command
	{
		public BaseTween tween;

		public JoinTweenCommand(BaseTween tween, Sequence sequence) : base(sequence)
		{
			this.tween = tween;
		}

		public override void Execute()
		{
			tween.ReplayReset();
			TweenPool.activeTweens.Add(tween);
			tween.SetOnComplete(() => tween.IsComplete = true);
			tween.SetOnComplete(() => TweenPool.activeTweens.Remove(tween));
			sequence.Join(tween);
		}
	}
	
}

