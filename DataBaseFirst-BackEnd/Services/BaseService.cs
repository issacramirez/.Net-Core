using DataBaseFirst_BackEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFirst_BackEnd.Services {
    public class BaseService {
        protected NORTHWNDContext dataContext = new NORTHWNDContext();
    }
}
