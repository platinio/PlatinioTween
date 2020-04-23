using UnityEngine;
using UnityEngine.UI;

namespace Platinio
{
	public class Lifebar : MonoBehaviour
	{
		[SerializeField] private Image lifebarImg = null;
		[SerializeField] private Image lifebarFollowImg = null;
		[SerializeField] private Gradient gradient = null;
		[SerializeField] private float hp = 100.0f;
		[SerializeField] private float followTime = 1.0f;
		[SerializeField] private Ease ease = Ease.EaseOutExpo;

		private float maxHP = 0.0f;

		private void Awake()
		{
			maxHP = hp;
			lifebarImg.color = gradient.Evaluate(1.0f);
		}

		public void HandleDamage(float dmg)
		{
			hp = Mathf.Max(0.0f , hp - dmg);

			gameObject.CancelAllTweens();
			float targetFill = hp / maxHP;			
			lifebarImg.ColorTween(gradient.Evaluate(targetFill) , 0.35f).SetOwner(gameObject);
			lifebarImg.FillAmountTween(targetFill, 0.35f).SetEase(ease).SetOwner(gameObject);
			lifebarFollowImg.FillAmountTween(targetFill , followTime).SetEase(ease).SetOwner(gameObject);
			
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
				HandleDamage(maxHP / 20);
		}


	}

}

