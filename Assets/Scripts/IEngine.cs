using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEngine
{
    public float engineSpeed {  get; set; }

    public void Move(Vector3 direction);
}
