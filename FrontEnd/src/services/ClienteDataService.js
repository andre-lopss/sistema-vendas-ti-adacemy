import http from "../http-common";

class ClienteDataService{
    listar(){
        return http.get("/cliente/listar")
    }
    cadastrar(cliente){
        return http.post('/cliente', cliente);
    }
    atualizar(id, cliente){
        return http.put(`/cliente/atualizar/${id}`, cliente)
    }
    obterPorId(id){
        return http.get(`/cliente/obterId/${id}`);
    }
    obterClienteNome(nome){
        return http.get(`/cliente/ConsultarPorNome/${nome}`);
    }
    async deletar(id){
        return await http.delete(`/cliente/${id}`);
    }
}
export default new ClienteDataService();