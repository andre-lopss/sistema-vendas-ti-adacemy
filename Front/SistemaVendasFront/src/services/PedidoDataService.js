import http from "../http-common";

class PedidoDataService{
    listar(){
        return http.get("/pedido/listar")
    }

    cadastrar(servico){
        return http.post('/pedido', servico);
    }

    atualizar(id, servico){
        return http.put(`/pedido/${id}`, servico)
    }
    
    obterPorId(id){
        return http.get(`/pedido/${id}`);
    }

    async deletar(id){
        return await http.delete(`/pedido/${id}`);
    }
}
export default new PedidoDataService();