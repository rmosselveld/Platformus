﻿// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Infrastructure;

namespace Platformus.ExtensionManager
{
  public class BackendMetadata : BackendMetadataBase
  {
    public override IEnumerable<BackendStyleSheet> BackendStyleSheets
    {
      get
      {
        return new BackendStyleSheet[]
        {
          new BackendStyleSheet("/wwwroot.areas.backend.css.platformus.extension_manager.min.css", 4000)
        };
      }
    }

    public override IEnumerable<BackendScript> BackendScripts
    {
      get
      {
        return new BackendScript[]
        {
          new BackendScript("/wwwroot.areas.backend.js.platformus.extension_manager.min.js", 4000)
        };
      }
    }

    public override IEnumerable<BackendMenuGroup> BackendMenuGroups
    {
      get
      {
        return new BackendMenuGroup[]
        {
          new BackendMenuGroup(
            "Development",
            4000,
            new BackendMenuItem[]
            {
              new BackendMenuItem("/backend/extensionmanager", "Extension manager", 1000, new string[] { Permissions.BrowseExtensionManager })
            }
          )
        };
      }
    }
  }
}