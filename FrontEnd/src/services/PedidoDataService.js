import http from "../http-common";

class PedidoDataService{
    listar(){
        return http.get("/pedido/listar")
    }
    listarPorVendedor(id){
        return http.get('/pedido/vendedor/'+ id)
    }
    listarPorCliente(id){
        return http.get('/pedido/cliente/'+ id)
    }
    cadastrar(pedido){
        return http.post('/pedido', pedido);
    }
    atualizar(id, pedido){
        return http.put(`/pedido/atualizar/${id}`, pedido)
    }
    obterPorId(id){
        return http.get(`/pedido/obterId/${id}`);
    }
    obterPorIdVendedor(id){
        return http.get(`/pedido/vendedor/${id}`);
    }
    async deletar(id){
        return await http.delete(`/pedido/${id}`);
    }
}
export default new PedidoDataService();