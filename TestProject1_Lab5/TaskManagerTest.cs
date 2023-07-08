﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5;

namespace TestProject1_Lab5
{
    public class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new Lab5.Task("Zadanie do dodania");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new Lab5.Task("Zadanie do usunięcia");
            _taskManager.AddTask(task);
            int initialTaskCount = _taskManager.GetTasks().Count;

            // Act
            _taskManager.RemoveTask(task.Id);

            // Assert
            Assert.AreEqual(initialTaskCount - 1, _taskManager.GetTasks().Count);
            Assert.AreEqual(false, _taskManager.GetTasks().Contains(task));
        }

        [Test]
        public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
        {
            // Arrange
            var task = new Lab5.Task("Zadanie nie do usunięcia");
            _taskManager.AddTask(task);
            int initialTaskCount = _taskManager.GetTasks().Count;

            // Act
            _taskManager.RemoveTask(99);

            // Assert
            Assert.AreEqual(initialTaskCount, _taskManager.GetTasks().Count);
            Assert.AreEqual(true, _taskManager.GetTasks().Contains(task));
        }

        [Test]
        public void MarkTaskAsCompleted_ExistingTask_ShouldMarkTaskAsCompleted()
        {
            // Arrange
            var task = new Lab5.Task("Zadanie do ukończenia");
            _taskManager.AddTask(task);
            // Act
            _taskManager.MarkTaskAsCompleted(task.Id);
            // Assert
            Assert.AreEqual(true, _taskManager.GetTaskById(task.Id).IsCompleted);
        }

        [Test]
        public void MarkTaskAsCompleted_NonExistingTask_ShouldNotMarkTaskAsCompleted()
        {
            // Arrange
            var task = new Lab5.Task("Zadanie nie do ukończenia");
            _taskManager.AddTask(task);
            // Act
            _taskManager.MarkTaskAsCompleted(99);
            // Assert
            Assert.AreEqual(false, _taskManager.GetTaskById(task.Id).IsCompleted);
        }

        [Test]
        public void GetTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var task1 = new Lab5.Task("Zadanie do zwrócenia 1");
            var task2 = new Lab5.Task("Zadanie do zwrócenia 2");
            _taskManager.AddTask(task1);
            _taskManager.AddTask(task2);

            // Act
            List<Lab5.Task> tasks = _taskManager.GetTasks();

            // Assert
            Assert.Contains(task1, tasks);
            Assert.Contains(task2, tasks);
            Assert.AreEqual(2, tasks.Count);
        }

        


    }
}
