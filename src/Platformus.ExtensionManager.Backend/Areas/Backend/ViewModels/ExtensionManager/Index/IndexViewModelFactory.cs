﻿// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Barebone;
using Platformus.Barebone.Backend.ViewModels;
using Platformus.Barebone.Backend.ViewModels.Shared;
using Platformus.ExtensionManager.Backend.ViewModels.Shared;

namespace Platformus.ExtensionManager.Backend.ViewModels.ExtensionManager
{
  public class IndexViewModelFactory : ViewModelFactoryBase
  {
    public IndexViewModelFactory(IRequestHandler requestHandler)
      : base(requestHandler)
    {
    }

    public IndexViewModel Create(string orderBy, string direction, int skip, int take, string filter)
    {
      string extensionsPath = PathManager.GetExtensionsPath(this.RequestHandler);
      
      return new IndexViewModel()
      {
        Grid = new GridViewModelFactory(this.RequestHandler).Create(
          orderBy, direction, skip, take, FileSystemRepository.CountFiles(extensionsPath, "*.extension", filter),
          new[] {
            new GridColumnViewModelFactory(this.RequestHandler).Create("ID", "filename"),
            new GridColumnViewModelFactory(this.RequestHandler).Create("Name", string.Empty),
            new GridColumnViewModelFactory(this.RequestHandler).Create("Version", string.Empty),
            new GridColumnViewModelFactory(this.RequestHandler).CreateEmpty()
          },
          FileSystemRepository.GetFiles(extensionsPath, "*.extension", filter, orderBy, direction, skip, take).Select(fi => new ExtensionViewModelFactory(this.RequestHandler).Create(fi)),
          "_Extension"
        )
      };
    }
  }
}