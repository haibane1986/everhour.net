namespace Everhour.Net.Tests
{
    public static class Specification
    {
        #region ACCESS_DENIED
        public static string ACCESS_DENIED = @"
{
  ""code"":403,
  ""message"":""Access denied""
}
        ";
        #endregion

        #region EXPORT_ESITIMATES
        public static string EXPORT_ESITIMATES = @"
[
  {
    ""time"": {
      ""total"": 7200,
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""estimate"": {
      ""total"": 7200,
      ""type"": ""overall"",
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""project"": {
      ""id"": ""ev:9876543210"",
      ""name"": ""Project Name"",
      ""workspace"": ""Project Workspace Name""
    },
    ""task"": {
      ""id"": ""ev:1234567890"",
      ""name"": ""Task Name"",
      ""status"": ""open"",
      ""type"": ""task"",
      ""iteration"": ""Iteration/column/section name"",
      ""number"": 123,
      ""dueAt"": ""2018-01-20""
    }
  }
]
        ";
        #endregion

        #region EXPORT_TIME
        public static string EXPORT_TIME = @"
[
  {
    ""time"": 7200,
    ""date"": ""2018-03-20"",
    ""user"": {
      ""id"": 1304,
      ""name"": ""Chris Wonder""
    },
    ""project"": {
      ""id"": ""ev:9876543210"",
      ""name"": ""Project Name"",
      ""workspace"": ""Project Workspace Name""
    },
    ""task"": {
      ""id"": ""ev:1234567890"",
      ""name"": ""Task Name"",
      ""status"": ""open"",
      ""type"": ""task"",
      ""iteration"": ""Iteration/column/section name"",
      ""number"": 123,
      ""dueAt"": ""2018-01-20""
    }
  }
]
        ";

        #endregion

        #region LIST_CLIENTS
        public static string LIST_CLIENTS = @"
[
  {
    ""id"": 4567,
    ""name"": ""Client Name"",
    ""businessDetails"": ""hoge"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""budget"": {
      ""type"": ""money"",
      ""budget"": 100000,
      ""progress"": 1
    }
  },
  {
    ""id"": 4568,
    ""name"": ""Client Name"",
    ""businessDetails"": ""hoge"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""budget"": {
      ""type"": ""money"",
      ""budget"": 100000,
      ""progress"": 1
    }
  }
]
        ";
        #endregion

        #region CREATE_CLIENT
        public static string CREATE_CLIENT = @"
{
  ""id"": 4567,
  ""name"": ""Client Name"",
  ""businessDetails"": ""hoge"",
  ""projects"": [
    ""ev:1234567890""
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  }
}
        ";
        #endregion

        #region RITRIEVE_CLIENT
        public static string RETRIEVE_CLIENT = @"
{
  ""id"": 4567,
  ""name"": ""Client Name"",
  ""businessDetails"": ""hoge"",
  ""projects"": [
    ""ev:1234567890""
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  }
}
        ";
        #endregion

        #region UPDATE_CLIENT
        public static string UPDATE_CLIENT = @"
{
  ""id"": 4567,
  ""name"": ""Client Name"",
  ""businessDetails"": ""hoge"",
  ""projects"": [
    ""ev:1234567890""
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  }
}
        ";
        #endregion

        #region RITRIEVE_CLIENT
        public static string SET_CLIENT_BUDGET = @"
{
  ""id"": 4567,
  ""name"": ""Client Name"",
  ""businessDetails"": ""hoge"",
  ""projects"": [
    ""ev:1234567890""
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  }
}
        ";
        #endregion

        #region LIST_ALL_PROJECTS
        public static string LIST_ALL_PROJECTS = @"
[
  {
    ""id"": ""as:1234567890"",
    ""name"": ""Project Name"",
    ""workspaceId"": ""as:9876543219"",
    ""workspaceName"": ""Workspace Name"",
    ""type"": ""board"",
    ""favorite"": true,
    ""users"": [
      1304,
      1543
    ],
    ""budget"": {
      ""type"": ""money"",
      ""budget"": 100000,
      ""progress"": 1
    },
    ""billing"": {
      ""type"": ""flat_rate"",
      ""rate"": 10000,
      ""users"": {
        ""1304"": 10000,
        ""1543"": 5000
      }
    }
  },
  {
    ""id"": ""as:1234567899"",
    ""name"": ""Project Name"",
    ""workspaceId"": ""as:9876543219"",
    ""workspaceName"": ""Workspace Name"",
    ""type"": ""board"",
    ""favorite"": true,
    ""users"": [
      1304,
      1543
    ],
    ""budget"": {
      ""type"": ""money"",
      ""budget"": 100000,
      ""progress"": 1
    },
    ""billing"": {
      ""type"": ""flat_rate"",
      ""rate"": 10000,
      ""users"": {
        ""1304"": 10000,
        ""1543"": 5000
      }
    }
  }
]
        ";
        #endregion

        #region CREATE_PROJECT
        public static string CREATE_PROJECT = @"
{
  ""id"": ""as:1234567890"",
  ""name"": ""Project Name"",
  ""workspaceId"": ""as:9876543219"",
  ""workspaceName"": ""Workspace Name"",
  ""type"": ""board"",
  ""favorite"": true,
  ""users"": [
    1304,
    1543
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  },
  ""billing"": {
    ""type"": ""flat_rate"",
    ""rate"": 10000,
    ""users"": {
      ""1304"": 10000,
      ""1543"": 5000
    }
  }
}
        ";
        #endregion

        #region RETRIEVE_PROJECT
        public static string RETRIEVE_PROJECT = @"
{
  ""id"": ""as:1234567890"",
  ""name"": ""Project Name"",
  ""workspaceId"": ""as:9876543219"",
  ""workspaceName"": ""Workspace Name"",
  ""type"": ""board"",
  ""favorite"": true,
  ""users"": [
    1304,
    1543
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  },
  ""billing"": {
    ""type"": ""flat_rate"",
    ""rate"": 10000,
    ""users"": {
      ""1304"": 10000,
      ""1543"": 5000
    }
  }
}
        ";
        #endregion

        #region UPDATE_PROJECT

        public static string UPDATE_PROJECT = @"
{
  ""id"": ""as:1234567890"",
  ""name"": ""Project Name"",
  ""workspaceId"": ""as:9876543219"",
  ""workspaceName"": ""Workspace Name"",
  ""type"": ""board"",
  ""favorite"": true,
  ""users"": [
    1304,
    1543
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  },
  ""billing"": {
    ""type"": ""flat_rate"",
    ""rate"": 10000,
    ""users"": {
      ""1304"": 10000,
      ""1543"": 5000
    }
  }
}
        ";
        #endregion

        #region SET_PROJECT_BUDGET

        public static string SET_PROJECT_BUDGET = @"
{
  ""id"": ""as:1234567890"",
  ""name"": ""Project Name"",
  ""workspaceId"": ""as:9876543219"",
  ""workspaceName"": ""Workspace Name"",
  ""type"": ""board"",
  ""favorite"": true,
  ""users"": [
    1304,
    1543
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  },
  ""billing"": {
    ""type"": ""flat_rate"",
    ""rate"": 10000,
    ""users"": {
      ""1304"": 10000,
      ""1543"": 5000
    }
  }
}
        ";
        #endregion

        #region SET_PROJECT_BILLING

        public static string SET_PROJECT_BILLING = @"
{
  ""id"": ""as:1234567890"",
  ""name"": ""Project Name"",
  ""workspaceId"": ""as:9876543219"",
  ""workspaceName"": ""Workspace Name"",
  ""type"": ""board"",
  ""favorite"": true,
  ""users"": [
    1304,
    1543
  ],
  ""budget"": {
    ""type"": ""money"",
    ""budget"": 100000,
    ""progress"": 1
  },
  ""billing"": {
    ""type"": ""flat_rate"",
    ""rate"": 10000,
    ""users"": {
      ""1304"": 10000,
      ""1543"": 5000
    }
  }
}
        ";
        #endregion

        #region LIST_PROJECT_SECTIONS

        public static string LIST_PROJECT_SECTIONS = @"
[
  {
    ""id"": 1234,
    ""name"": ""Section Name"",
    ""project"": ""ev:1234567890"",
    ""position"": 1,
    ""status"": ""open""
  }
]
        ";
        #endregion

        #region CREATE_SECTION
        public static string CREATE_SECTION = @"
{
  ""id"": 1234,
  ""name"": ""Section Name"",
  ""project"": ""ev:1234567890"",
  ""position"": 1,
  ""status"": ""open""
}
        ";
        #endregion

        #region RETRIEVE_SECTION
        public static string RETRIEVE_SECTION = @"
{
  ""id"": 1234,
  ""name"": ""Section Name"",
  ""project"": ""ev:1234567890"",
  ""position"": 1,
  ""status"": ""open""
}
        ";
        #endregion

        #region UPDATE_SECTION
        public static string UPDATE_SECTION = @"
{
  ""id"": 1234,
  ""name"": ""Section Name"",
  ""project"": ""ev:1234567890"",
  ""position"": 1,
  ""status"": ""open""
}
        ";
        #endregion

        #region LIST_PROJECT_TASKS
        public static string LIST_PROJECT_TASKS = @"
[
  {
    ""id"": ""ev:9876543210"",
    ""name"": ""Task Name"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""section"": 1234,
    ""labels"": [
      ""high"",
      ""bug""
    ],
    ""position"": 1,
    ""description"": ""description"",
    ""dueAt"": ""2018-03-05 16:00:00"",
    ""status"": ""open"",
    ""time"": {
      ""total"": 7200,
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""estimate"": {
      ""total"": 7200,
      ""type"": ""overall"",
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""attributes"": [{
      ""Client"": ""Everhour"",
      ""Priority"": ""hight""
    }],
    ""metrics"": [{
      ""efforts"": 42,
      ""expenses"": 199
    }]
  }
]
        ";
        #endregion

        #region CREATE_TASK
        public static string CREATE_TASK = @"
{
  ""id"": ""ev:9876543210"",
  ""name"": ""Task Name"",
  ""projects"": [
    ""ev:1234567890""
  ],
  ""section"": 1234,
  ""labels"": [
    ""high"",
    ""bug""
  ],
  ""position"": 1,
  ""description"": ""description"",
  ""dueAt"": ""2018-03-05 16:00:00"",
  ""status"": ""open"",
  ""time"": {
    ""total"": 7200,
    ""users"": {
      ""1304"": 3600,
      ""1543"": 3600
    }
  },
  ""estimate"": {
    ""total"": 7200,
    ""type"": ""overall"",
    ""users"": {
      ""1304"": 3600,
      ""1543"": 3600
    }
  },
  ""attributes"": [{
    ""Client"": ""Everhour"",
    ""Priority"": ""hight""
  }],
  ""metrics"": [{
    ""efforts"": 42,
    ""expenses"": 199
  }]
}
        ";
        #endregion

        #region RETRIEVE_TASK
        public static string RETRIEVE_TASK = @"
{
  ""id"": ""ev:9876543210"",
  ""name"": ""Task Name"",
  ""projects"": [
    ""ev:1234567890""
  ],
  ""section"": 1234,
  ""labels"": [
    ""high"",
    ""bug""
  ],
  ""position"": 1,
  ""description"": ""description"",
  ""dueAt"": ""2018-03-05 16:00:00"",
  ""status"": ""open"",
  ""time"": {
    ""total"": 7200,
    ""users"": {
      ""1304"": 3600,
      ""1543"": 3600
    }
  },
  ""estimate"": {
    ""total"": 7200,
    ""type"": ""overall"",
    ""users"": {
      ""1304"": 3600,
      ""1543"": 3600
    }
  },
  ""attributes"": [{
    ""Client"": ""Everhour"",
    ""Priority"": ""hight""
  }],
  ""metrics"": [{
    ""efforts"": 42,
    ""expenses"": 199
  }]
}
        ";
        #endregion

        #region UPDATE_TASK
        public static string UPDATE_TASK = @"
{
  ""id"": ""ev:9876543210"",
  ""name"": ""Task Name"",
  ""projects"": [
    ""ev:1234567890""
  ],
  ""section"": 1234,
  ""labels"": [
    ""high"",
    ""bug""
  ],
  ""position"": 1,
  ""description"": ""description"",
  ""dueAt"": ""2018-03-05 16:00:00"",
  ""status"": ""open"",
  ""time"": {
    ""total"": 7200,
    ""users"": {
      ""1304"": 3600,
      ""1543"": 3600
    }
  },
  ""estimate"": {
    ""total"": 7200,
    ""type"": ""overall"",
    ""users"": {
      ""1304"": 3600,
      ""1543"": 3600
    }
  },
  ""attributes"": [{
    ""Client"": ""Everhour"",
    ""Priority"": ""hight""
  }],
  ""metrics"": [{
    ""efforts"": 42,
    ""expenses"": 199
  }]
}
        ";
        #endregion

        #region SET_TASK_ESTIMATE
        public static string SET_TASK_ESTIMATE = @"
{
  ""type"":""overall"",
  ""total"":7200
}
        ";
        #endregion

        #region ME
        public static string ME = @"
{
  ""id"": 1304,
  ""name"": ""User Name"",
  ""headline"": ""CEO"",
  ""role"": ""admin"",
  ""status"": ""active""
}
        ";
        #endregion

        #region LIST_USERS
        public static string LIST_USERS = @"
[
  {
    ""id"": 1304,
    ""name"": ""User Name"",
    ""headline"": ""CEO"",
    ""role"": ""admin"",
    ""status"": ""active"",
    ""avatarUrl"": ""https://hoge""
  },
  {
    ""id"": 1305,
    ""name"": ""User Name"",
    ""headline"": ""Developer"",
    ""role"": ""admin"",
    ""status"": ""active"",
    ""avatarUrl"": ""https://moge""
  }
]
        ";
        #endregion

        #region ADD_TIME_TO_TASK
        public static string ADD_TIME_TO_TASK = @"
{
  ""id"": 2660155,
  ""time"": 3600,
  ""user"": 1304,
  ""date"": ""2018-01-20"",
  ""task"": {
    ""id"": ""ev:9876543210"",
    ""name"": ""Task Name"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""section"": 1234,
    ""labels"": [
      ""high"",
      ""bug""
    ],
    ""position"": 1,
    ""description"": ""description"",
    ""dueAt"": ""2018-03-05 16:00:00"",
    ""status"": ""open"",
    ""time"": {
      ""total"": 7200,
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""estimate"": {
      ""total"": 7200,
      ""type"": ""overall"",
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""attributes"": [{
      ""Client"": ""Everhour"",
      ""Priority"": ""hight""
    }],
    ""metrics"": [{
      ""efforts"": 42,
      ""expenses"": 199
    }]
  },
  ""isLocked"": true,
  ""isInvoiced"": true,
  ""comment"": ""some notes""
}
        ";
        #endregion

        #region UPDATE_TIME_IN_TASK
        public static string UPDATE_TIME_IN_TASK = @"
{
  ""id"": 2660155,
  ""time"": 3600,
  ""user"": 1304,
  ""date"": ""2018-01-20"",
  ""task"": {
    ""id"": ""ev:9876543210"",
    ""name"": ""Task Name"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""section"": 1234,
    ""labels"": [
      ""high"",
      ""bug""
    ],
    ""position"": 1,
    ""description"": ""description"",
    ""dueAt"": ""2018-03-05 16:00:00"",
    ""status"": ""open"",
    ""time"": {
      ""total"": 7200,
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""estimate"": {
      ""total"": 7200,
      ""type"": ""overall"",
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""attributes"": [{
      ""Client"": ""Everhour"",
      ""Priority"": ""hight""
    }],
    ""metrics"": [{
      ""efforts"": 42,
      ""expenses"": 199
    }]
  },
  ""isLocked"": true,
  ""isInvoiced"": true,
  ""comment"": ""some notes""
}
        ";
        #endregion

        #region DELETE_TIME_IN_TASK
        public static string DELETE_TIME_IN_TASK = @"
{
  ""id"": 2660155,
  ""time"": 3600,
  ""user"": 1304,
  ""date"": ""2018-01-20"",
  ""task"": {
    ""id"": ""ev:9876543210"",
    ""name"": ""Task Name"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""section"": 1234,
    ""labels"": [
      ""high"",
      ""bug""
    ],
    ""position"": 1,
    ""description"": ""description"",
    ""dueAt"": ""2018-03-05 16:00:00"",
    ""status"": ""open"",
    ""time"": {
      ""total"": 7200,
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""estimate"": {
      ""total"": 7200,
      ""type"": ""overall"",
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""attributes"": [{
      ""Client"": ""Everhour"",
      ""Priority"": ""hight""
    }],
    ""metrics"": [{
      ""efforts"": 42,
      ""expenses"": 199
    }]
  },
  ""isLocked"": true,
  ""isInvoiced"": true,
  ""comment"": ""some notes""
}
        ";
        #endregion

        #region LIST_USER_TIME_RECORDS
        public static string LIST_USER_TIME_RECORDS = @"
[
  {
    ""id"": 2660155,
    ""time"": 3600,
    ""user"": 1304,
    ""date"": ""2018-01-20"",
    ""task"": {
      ""id"": ""ev:9876543210"",
      ""name"": ""Task Name"",
      ""projects"": [
        ""ev:1234567890""
      ],
      ""section"": 1234,
      ""labels"": [
        ""high"",
        ""bug""
      ],
      ""position"": 1,
      ""description"": ""description"",
      ""dueAt"": ""2018-03-05 16:00:00"",
      ""status"": ""open"",
      ""time"": {
        ""total"": 7200,
        ""users"": {
          ""1304"": 3600,
          ""1543"": 3600
        }
      },
      ""estimate"": {
        ""total"": 7200,
        ""type"": ""overall"",
        ""users"": {
          ""1304"": 3600,
          ""1543"": 3600
        }
      },
      ""attributes"": [{
        ""Client"": ""Everhour"",
        ""Priority"": ""hight""
      }],
      ""metrics"": [{
        ""efforts"": 42,
        ""expenses"": 199
      }]
    },
    ""isLocked"": true,
    ""isInvoiced"": true,
    ""comment"": ""some notes""
  }
]
        ";
        #endregion

        #region LIST_TEAM_TIME_RECORDS
        public static string LIST_TEAM_TIME_RECORDS = @"
[
  {
    ""id"": 2660155,
    ""time"": 3600,
    ""user"": 1304,
    ""date"": ""2018-01-20"",
    ""task"": {
      ""id"": ""ev:9876543210"",
      ""name"": ""Task Name"",
      ""projects"": [
        ""ev:1234567890""
      ],
      ""section"": 1234,
      ""labels"": [
        ""high"",
        ""bug""
      ],
      ""position"": 1,
      ""description"": ""description"",
      ""dueAt"": ""2018-03-05 16:00:00"",
      ""status"": ""open"",
      ""time"": {
        ""total"": 7200,
        ""users"": {
          ""1304"": 3600,
          ""1543"": 3600
        }
      },
      ""estimate"": {
        ""total"": 7200,
        ""type"": ""overall"",
        ""users"": {
          ""1304"": 3600,
          ""1543"": 3600
        }
      },
      ""attributes"": [{
        ""Client"": ""Everhour"",
        ""Priority"": ""hight""
      }],
      ""metrics"": [{
        ""efforts"": 42,
        ""expenses"": 199
      }]
    },
    ""isLocked"": true,
    ""isInvoiced"": true,
    ""comment"": ""some notes"",
    ""history"": [
      {
        ""id"": 4622379,
        ""createdBy"": 1304,
        ""time"": 3600,
        ""previousTime"": 0,
        ""status"": ""TIMER"",
        ""createdAt"": ""2018-01-16 12:42:59""
      }
    ]
  }
]
        ";
        #endregion

        #region LIST_TASK_TIME_RECORDS
        public static string LIST_TASK_TIME_RECORDS = @"
[
  {
    ""id"": 2660155,
    ""time"": 3600,
    ""user"": 1304,
    ""date"": ""2018-01-20"",
    ""task"": {
      ""id"": ""ev:9876543210"",
      ""name"": ""Task Name"",
      ""projects"": [
        ""ev:1234567890""
      ],
      ""section"": 1234,
      ""labels"": [
        ""high"",
        ""bug""
      ],
      ""position"": 1,
      ""description"": ""description"",
      ""dueAt"": ""2018-03-05 16:00:00"",
      ""status"": ""open"",
      ""time"": {
        ""total"": 7200,
        ""users"": {
          ""1304"": 3600,
          ""1543"": 3600
        }
      },
      ""estimate"": {
        ""total"": 7200,
        ""type"": ""overall"",
        ""users"": {
          ""1304"": 3600,
          ""1543"": 3600
        }
      },
      ""attributes"": [{
        ""Client"": ""Everhour"",
        ""Priority"": ""hight""
      }],
      ""metrics"": [{
        ""efforts"": 42,
        ""expenses"": 199
      }]
    },
    ""isLocked"": true,
    ""isInvoiced"": true,
    ""comment"": ""some notes""
  }
]
        ";
        #endregion

        #region START_TIMER
        public static string START_TIMER = @"
{
  ""status"": ""active"",
  ""duration"": 16,
  ""today"": 7200,
  ""startedAt"": ""2018-01-16 12:42:59"",
  ""userDate"": ""2018-01-16"",
  ""comment"": ""comment"",
  ""task"": {
    ""id"": ""ev:9876543210"",
    ""name"": ""Task Name"",
    ""description"": ""description"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""section"": 1234,
    ""labels"": [
      ""high"",
      ""bug""
    ],
    ""position"": 1,
    ""dueAt"": ""2018-03-05 16:00:00"",
    ""status"": ""open"",
    ""time"": {
      ""total"": 7200,
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""estimate"": {
      ""total"": 7200,
      ""type"": ""overall"",
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""attributes"": [{
      ""Client"": ""Everhour"",
      ""Priority"": ""hight""
    }],
    ""metrics"": [{
      ""efforts"": 42,
      ""expenses"": 199
    }]
  },
  ""user"": {
    ""id"": 1304,
    ""name"": ""User Name"",
    ""headline"": ""CEO"",
    ""role"": ""admin"",
    ""status"": ""active""
  }
}
        ";
        #endregion

        #region RETRIEVE_RUNNING_TIMER
        public static string RETRIEVE_RUNNING_TIMER = @"
{
  ""status"": ""active"",
  ""duration"": 16,
  ""today"": 7200,
  ""startedAt"": ""2018-01-16 12:42:59"",
  ""userDate"": ""2018-01-16"",
  ""comment"": ""comment"",
  ""task"": {
    ""id"": ""ev:9876543210"",
    ""name"": ""Task Name"",
    ""description"": ""description"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""section"": 1234,
    ""labels"": [
      ""high"",
      ""bug""
    ],
    ""position"": 1,
    ""dueAt"": ""2018-03-05 16:00:00"",
    ""status"": ""open"",
    ""time"": {
      ""total"": 7200,
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""estimate"": {
      ""total"": 7200,
      ""type"": ""overall"",
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""attributes"": [{
      ""Client"": ""Everhour"",
      ""Priority"": ""hight""
    }],
    ""metrics"": [{
      ""efforts"": 42,
      ""expenses"": 199
    }]
  },
  ""user"": {
    ""id"": 1304,
    ""name"": ""User Name"",
    ""headline"": ""CEO"",
    ""role"": ""admin"",
    ""status"": ""active""
  }
}
        ";
        #endregion

        #region STOP_TIMER
        public static string STOP_TIMER = @"
{
  ""status"": ""active"",
  ""duration"": 16,
  ""today"": 7200,
  ""startedAt"": ""2018-01-16 12:42:59"",
  ""userDate"": ""2018-01-16"",
  ""comment"": ""comment"",
  ""task"": {
    ""id"": ""ev:9876543210"",
    ""name"": ""Task Name"",
    ""description"": ""description"",
    ""projects"": [
      ""ev:1234567890""
    ],
    ""section"": 1234,
    ""labels"": [
      ""high"",
      ""bug""
    ],
    ""position"": 1,
    ""dueAt"": ""2018-03-05 16:00:00"",
    ""status"": ""open"",
    ""time"": {
      ""total"": 7200,
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""estimate"": {
      ""total"": 7200,
      ""type"": ""overall"",
      ""users"": {
        ""1304"": 3600,
        ""1543"": 3600
      }
    },
    ""attributes"": [{
      ""Client"": ""Everhour"",
      ""Priority"": ""hight""
    }],
    ""metrics"": [{
      ""efforts"": 42,
      ""expenses"": 199
    }]
  },
  ""user"": {
    ""id"": 1304,
    ""name"": ""User Name"",
    ""headline"": ""CEO"",
    ""role"": ""admin"",
    ""status"": ""active""
  }
}
        ";
        #endregion

        #region LIST_TEAM_USERS_TIMERS
        public static string LIST_TEAM_USERS_TIMERS = @"
[
  {
    ""status"": ""active"",
    ""duration"": 16,
    ""today"": 7200,
    ""startedAt"": ""2018-01-16 12:42:59"",
    ""userDate"": ""2018-01-16"",
    ""comment"": ""comment"",
    ""task"": {
      ""id"": ""ev:9876543210"",
      ""name"": ""Task Name"",
      ""description"": ""description"", 
      ""projects"": [
        ""ev:1234567890""
      ],
      ""section"": 1234,
      ""labels"": [
        ""high"",
        ""bug""
      ],
      ""position"": 1,
      ""dueAt"": ""2018-03-05 16:00:00"",
      ""status"": ""open"",
      ""time"": {
        ""total"": 7200,
        ""users"": {
          ""1304"": 3600,
          ""1543"": 3600
        }
      },
      ""estimate"": {
        ""total"": 7200,
        ""type"": ""overall"",
        ""users"": {
          ""1304"": 3600,
          ""1543"": 3600
        }
      },
      ""attributes"": [{
        ""Client"": ""Everhour"",
        ""Priority"": ""hight""
      }],
      ""metrics"": [{
        ""efforts"": 42,
        ""expenses"": 199
      }]
    },
    ""user"": {
      ""id"": 1304,
      ""name"": ""User Name"",
      ""headline"": ""CEO"",
      ""role"": ""admin"",
      ""status"": ""active""
    }
  }
]
        ";
        #endregion
    }
}