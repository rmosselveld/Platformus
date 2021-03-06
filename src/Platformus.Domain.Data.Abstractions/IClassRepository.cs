﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using ExtCore.Data.Abstractions;
using Platformus.Domain.Data.Entities;

namespace Platformus.Domain.Data.Abstractions
{
  public interface IClassRepository : IRepository
  {
    Class WithKey(int id);
    Class WithCode(string code);
    IEnumerable<Class> All();
    IEnumerable<Class> Range(string orderBy, string direction, int skip, int take, string filter);
    IEnumerable<Class> FilteredByClassId(int? classId);
    IEnumerable<Class> Abstract();
    IEnumerable<Class> NotAbstract();
    void Create(Class @class);
    void Edit(Class @class);
    void Delete(int id);
    void Delete(Class @class);
    int Count(string filter);
  }
}