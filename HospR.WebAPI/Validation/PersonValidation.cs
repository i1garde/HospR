using LanguageExt;

namespace HospR.WebAPI.Validation;

public static class PersonValidation
{
    public static Func<string, Option<string>> NumberValidator = s =>
    {
        return s[0] == '+' && s.Length == 13 ? Option<string>.Some(s) : Option<string>.None;
    };
}