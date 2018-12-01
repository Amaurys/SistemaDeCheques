using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeCheques.Models
{
    [AttributeUsage(AttributeTargets.Property |
AttributeTargets.Field, AllowMultiple = false)]
    sealed public class IdValidator : ValidationAttribute
    {

        public override bool IsValid(object value)
        {

            string cedula = value.ToString();
            int vnTotal = 0;
            string vcCedula = cedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
            {

                return true;
            }
            else
            {

                return false;
            }

        }
    }
}
    
