using System;
using System.Collections.Generic;

namespace StoresManagementApp.Admin.Model
{
    public class TaskModel
    {
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public string TaskTitle { get; set; }
        public List<EmployeeTask> employeeTasks { get; set; }
    }
    public class EmployeeTask
    {
        public string TaskName { get; set; }
    }
}
