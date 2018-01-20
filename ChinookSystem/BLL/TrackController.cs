﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Track_List()
        {
            //create a transaction instance of context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.OrderBy(x => x.Name).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track Track_Get(int trackid)
        {
            //create a transaction instance of context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.Find(trackid);
            }
        }
    }
}