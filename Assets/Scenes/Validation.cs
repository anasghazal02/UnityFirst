using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class input : MonoBehaviour
{
    [SerializeField] InputField email;
    [SerializeField] InputField pass;
    [SerializeField] Text resText;

    public void InputValidation()
    {

        string password = pass.text;
        string em = email.text;

        bool emBB = true;

        int requiredLength = 8;
        bool requiredPass = true;
        bool requireUppercase = true;
        bool requireLowercase = true;
        bool requireDigit = true;
        bool requireSpecialChar = true;
        string specialChars = "!@#$%^&*()";

        try
        {
            var mailAddress = new MailAddress(em);
            emBB = true;
        }
        catch (FormatException)
        {
            emBB = false;
        }

        if (password.Length < requiredLength)
            requiredPass = false;

        if (requireUppercase && !password.Any(char.IsUpper))
            requireUppercase = false;

        if (requireLowercase && !password.Any(char.IsLower))
            requireLowercase = false;

        if (requireDigit && !password.Any(char.IsDigit))
            requireDigit = false;

        if (requireSpecialChar && !password.Any(c => specialChars.Contains(c)))
            requireSpecialChar = false;

        if(requireDigit && requireLowercase && requireSpecialChar && requireUppercase && requiredPass && emBB)
        {
            resText.text = "Valid !!!";
            resText.color = Color.green;
        }
        else
        {
            resText.text = "Invalid Input";
            resText.color = Color.red;
        }

    }
}
