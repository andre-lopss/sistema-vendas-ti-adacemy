import http from "../http-common";

class ItemPedidoDataService{
    listar(){
        return http.get("/itemPedido/listar")
    }

    listarPorPedido(id){
        return http.get('/itemPedido/pedido/'+id)
    }

    cadastrar(itemPedido){
        return http.post('/itemPedido', itemPedido);
    }

    atualizar(id, itemPedido){
        return http.put(`/ItemPedido/${id}`, itemPedido)
    }
    
    obterPorId(id){
        return http.get(`/ItemPedido/${id}`);
    }

    async deletar(id){
        return await http.delete(`/itemPedido/${id}`);
    }
}
export default new ItemPedidoDataService();