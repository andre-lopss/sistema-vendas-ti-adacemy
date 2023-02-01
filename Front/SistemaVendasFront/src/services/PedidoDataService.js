import http from "../http-common";

class PedidoDataService{
    listar(){
        return http.get("/pedido/listar")
    }

    cadastrar(pedido){
        return http.post('/pedido', pedido);
    }

    atualizar(id, pedido){
        return http.put(`/pedido/${id}`, pedido)
    }
    
    obterPorId(id){
        return http.get(`/pedido/${id}`);
    }

    async deletar(id){
        return await http.delete(`/pedido/${id}`);
    }
}
export default new PedidoDataService();