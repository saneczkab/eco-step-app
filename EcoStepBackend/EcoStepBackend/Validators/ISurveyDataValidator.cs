namespace EcoStepBackend.Validators;

public interface ISurveyDataValidator<in T>
{
    void Validate(User user, T data, double days);
}
