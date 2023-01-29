using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public static class ButtonExtension 
{
   public static void AddEventListener<T>(this Button btn, T param, Action<T> OnClick){
        btn.onClick.AddListener(delegate(){
            OnClick(param);
        });
   }
}
