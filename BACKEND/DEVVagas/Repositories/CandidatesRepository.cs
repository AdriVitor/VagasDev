using DEVVagas.Models;

public static class CandidateRepository{
    public static Candidate Get(Candidate model){
        var users = new List<Candidate>{
            new(){Email = model.Email, Password = model.Password, Id = model.Id}
        };
        var validacao = users.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password && x.Id == model.Id);
        
        return validacao;
    }
}