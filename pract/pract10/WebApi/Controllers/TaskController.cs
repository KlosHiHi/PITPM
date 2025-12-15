using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        /// <summary>
        /// Список задач
        /// </summary>
        public List<TaskModel> TaskData { get; set; } = new()
        {
            new() { TaskId = 1, Name = "Приготовить торт", Description = "Скоро день рождения!", ExecutionTime = DateTime.Now.AddDays(2), Status = Model.TaskStatus.NotStart},
            new() { TaskId = 2, Name = "Доделать отчёты", Description = "Осталось ещё 40 штук.", ExecutionTime = DateTime.Now, Status = Model.TaskStatus.Delayed},
            new() { TaskId = 3, Name = "Оттадь долг", Description = "Брал пару тысяч на подарок.", ExecutionTime = DateTime.Now, Status = Model.TaskStatus.Delayed},
            new() { TaskId = 4, Name = "Доставить тюленя", Description = "Сейчас он спит.", ExecutionTime = DateTime.Now.AddDays(2), Status = Model.TaskStatus.Running},
            new() { TaskId = 5, Name = "Поспать", Description = "Всегда успею.", ExecutionTime = DateTime.Now, Status = Model.TaskStatus.Complete}
        };

        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <returns>Возвращает списко задач</returns>
        //GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<TaskModel> Get()
            => TaskData;

        /// <summary>
        /// Получение задачи по id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns>Возвращает задачу по ID</returns>
        //GET api/<TaskController>/3
        /// <response code="200">Успешное выполнение</response>
        /// <response code="404">Объекта с указанные ID нет</response>
        [HttpGet("{id}")]
        public TaskModel Get(int id)
        {
            var task = TaskData
                    .Where(t => t.TaskId == id)
                    .FirstOrDefault() ?? null!;

            if (task is null)
                BadRequest();

            return task;
        }

        /// <summary>
        /// Получение задачи по двум датам
        /// </summary>
        /// <param name="startDate">начальная дата поиска<param>
        /// <param name="endDate">конечная дата поиска</param>
        /// <returns>Возвращает задачи в заданном диапазоне</returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">В указанном диапазоне нет элементов</response>
        [HttpGet("{startDate}&{endDate}")]
        public IEnumerable<TaskModel> Get(DateTime startDate, DateTime endDate)
        {
            var task = TaskData
                    .Where(t => t.ExecutionTime > startDate && startDate <= endDate);

            if (task is null)
                BadRequest();

            return task.ToList();
        }

        /// <summary>
        /// Добавление задачи в список
        /// </summary>
        /// <param name="task">Добавляемая задача</param> 
        /// <remarks>
        /// 
        /// </remarks>
        /// <response code="201">Успешное добавление объекта</response>
        /// <response code="400">В указанном диапазоне нет элементов</response>
        //POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] TaskModel task)
        {
            var findTask = TaskData
                .Where(t => t.TaskId == task.TaskId)
                .FirstOrDefault() ?? null!;

            if (findTask is not null)
                BadRequest();

            TaskData.Add(task);
            Created();
        }

    /// <summary>
    /// Изменение объекта
    /// </summary>
    /// <remarks>
    /// Пример запроса
    /// {
    ///     "taskId": 0,
    ///     "name": "string",
    ///     "description": "string",
    ///     "executionTime": "2025-12-15T12:15:38.157Z",
    ///     "status": 0
    /// }
    /// </remarks>
    /// <param name="id">id изменяемого объекта</param>
    /// <param name="task">объект с новыми данными</param>
    /// <response code="200">Объект изменён</response>
    /// <response code="404">В указанном диапазоне нет элементов</response>
    //PUT api/<TaskController>/5
    [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskModel task)
        {
            var findTask = TaskData
                .Where(t => t.TaskId == task.TaskId)
                .FirstOrDefault() ?? null!;

            if (findTask is null)
                NotFound();

            TaskData.Remove(findTask);
            TaskData.Add(task);
            Ok();
        }

        /// <summary>
        /// Удаление задачи по id
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        /// <remarks>
        ///     Будьте осторожны, удалённые объекты вовзрату не подлежат!!!
        /// </remarks>
        /// <response code="200">Объект удалён</response>
        /// <response code="404">Объекта с указанным Id нет в списке</response>
        //DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleted = TaskData
                .Where(t => t.TaskId == id)
                .FirstOrDefault() ?? null!;

            if (deleted is null)
                NotFound();

            TaskData.Remove(deleted);
            Ok();
        }
    }
}
