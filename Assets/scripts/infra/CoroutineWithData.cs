using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameInfra {
	
public class CoroutineWithData<T> {
	public Coroutine coroutine { get; private set; }
	public T result;
	private IEnumerator target;

	public CoroutineWithData(MonoBehaviour owner, IEnumerable target) {
		this.target = target;
		this.coroutine = owner.StartCoroutine(Run());
	}

	private IEnumerable<T> Run() {
		while (target.MoveNext()) {
			result = (T) target.Current;
			yield return result;
		}
	}
}

}