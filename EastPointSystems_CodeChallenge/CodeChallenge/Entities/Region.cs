﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge.Entities
{
  public class Region
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ZipcodeGroup> Zipcodes { get; set; }
  }
}