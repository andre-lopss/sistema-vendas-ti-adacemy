import http from "../http-common";

class ServicoDataService{
    listar(){
        return http.get("/servico/listar")
    }
    cadastrar(servico){
        return http.post('/servico', servico);
    }
    atualizar(id, servico){
        return http.put(`/servico/${id}`, servico)
    }
    obterPorId(id){
        return http.get(`/servico/ObterId/${id}`);
    }
    obterServicoNome(nome){
        return http.get(`/servico/ConsultarPorNome/${nome}`);
    }
    async deletar(id){
        return await http.delete(`/servico/${id}`);
    }
}
export default new ServicoDataService();