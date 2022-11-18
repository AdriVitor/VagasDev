using DEVVagas.Models;

public static class RecruiterRepository{
    public static Recruiter Get(Recruiter model){
        var users = new List<Recruiter>{
            new(){Email = model.Email, Password = model.Password, Id = model.Id}
        };
        var validacao = users.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password && x.Id == model.Id);
        
        return validacao;
    }
}