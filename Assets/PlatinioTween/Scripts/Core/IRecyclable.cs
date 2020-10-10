using System;
namespace Platinio.TweenEngine
{
	public interface IRecyclable <T>
	{
		Action<T> Recycle { get; set; }
	}

}

