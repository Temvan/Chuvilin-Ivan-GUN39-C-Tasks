using System;
using UnityEngine;

namespace DefaultNamespace
{
	[RequireComponent(typeof(PositionSaver))]
	public class ReplayMover : MonoBehaviour
	{
		private PositionSaver _save;

		private int _index;
		private PositionSaver.Data _prev;
		private float _duration;

		private void Start()
		{
			////todo comment: зачем нужны эти проверки?
			/// ответ: проверяем наличие компонента и что в нем есть записи
			if (!TryGetComponent(out _save) || _save.Records.Count == 0)
			{
				Debug.LogError("Records incorrect value", this);
				//todo comment: Для чего выключается этот компонент?
				// ответ: чтобы отключить выполнение метода для записи позиций
				enabled = false;
			}
		}

		private void Update()
		{
			var curr = _save.Records[_index];
			//todo comment: Что проверяет это условие (с какой целью)? 
			// ответ: проверяет время текущее с временем кадра, чтобы перейти к следующей позиции
			if (Time.time > curr.Time)
			{
				_prev = curr;
				_index++;
				//todo comment: Для чего нужна эта проверка?
				// ответ: чтобы остановить запись, когда достигнут концец списка
				if (_index >= _save.Records.Count)
				{
					enabled = false;
					Debug.Log($"<b>{name}</b> finished", this);
				}
			}
			//todo comment: Для чего производятся эти вычисления (как в дальнейшем они применяются)?
			// ответ: для определения разницы времени между двумя позициями 
			var delta = (Time.time - _prev.Time) / (curr.Time - _prev.Time);
			//todo comment: Зачем нужна эта проверка?
			// ответ: чтобы не делить на ноль
			if (float.IsNaN(delta)) delta = 0f;
			//todo comment: Опишите, что происходит в этой строчке так подробно, насколько это возможно
			// ответ: происходит плавное перемещение объекта от предыдущей позиции _prev к текущей позиции curr в зависимости от значения разницы времени delta
			transform.position = Vector3.Lerp(_prev.Position, curr.Position, delta);
		}
	}
}