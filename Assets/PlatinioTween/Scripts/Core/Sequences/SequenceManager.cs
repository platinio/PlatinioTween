using System.Collections.Generic;


namespace Platinio.TweenEngine
{
	public static class SequenceManager
	{
		private static Stack<Sequence> sequencePool = new Stack<Sequence>();
		
		public static Sequence GetSequence()
		{
			if (sequencePool.Count <= 0)
			{
				return ProcessSequence(new Sequence(), false);
			}

			return ProcessSequence(sequencePool.Pop());
		}

		private static Sequence ProcessSequence(Sequence sequence, bool reset = true)
		{
			if (reset)
			{
				sequence.Reset();
			}

			sequence.Recycle = KillSequence;
			PlatinioTween.instance.OnUpdate += sequence.Update;
			return sequence;
		}

		public static void KillSequence(Sequence sequence)
		{
			PlatinioTween.instance.OnUpdate -= sequence.Update;
			sequence.Reset();
			sequencePool.Push(sequence);
		}
	}

}

