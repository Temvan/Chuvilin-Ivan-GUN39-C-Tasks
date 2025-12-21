using UnityEngine;

namespace DefaultNamespace
{
	
	[RequireComponent(typeof(PositionSaver))]
	public class EditorMover : MonoBehaviour
	{
		private PositionSaver _save;
		private float _currentDelay;

		//todo comment: Что произойдёт, если _delay > _duration?
		// ответ: время длительности будет меньше времени задержки, поэтому запись позиций не сохранится
		[SerializeField, Range(0.2f, 1f)]
		private float _delay = 0.5f;
        [SerializeField, Min(0.2f)]
        private float _duration = 5f;

		private void Start()
		{
			if (_duration <= _delay)
			{
				_duration = _delay * 5f;
			}

			_currentDelay = _delay;

            //todo comment: Почему этот поиск производится здесь, а не в начале метода Update?
            // ответ: чтобы изначально проинициализировать ссылку на помпонент, а потом уже обновлять данные
            _save = GetComponent<PositionSaver>();
			_save.Records.Clear();
		}

		private void Update()
		{
			_duration -= Time.deltaTime;
			if (_duration <= 0f)
			{
				enabled = false;
				Debug.Log($"<b>{name}</b> finished", this);
				return;
			}
			
			//todo comment: Почему не написать (_delay -= Time.deltaTime;) по аналогии с полем _duration?
			// ответ: чтобы каждый раз не сбрасывать константу задержки, а вычитать текущее значение
			_currentDelay -= Time.deltaTime;
			if (_currentDelay <= 0f)
			{
				_currentDelay = _delay;
				_save.Records.Add(new PositionSaver.Data
				{
					Position = transform.position,
					//todo comment: Для чего сохраняется значение игрового времени?
					// ответ: чтобы записать время сохранения позиции
					Time = Time.time,
				});
			}
		}
	}
}