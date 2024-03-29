import http from "../http-common";

class VendedorDataService{
    listar(){
        return http.get("/vendedor/listar")
    }
    cadastrar(vendedor){
        return http.post('/vendedor', vendedor);
    }
    atualizar(id, vendedor){
        return http.put(`/vendedor/${id}`, vendedor)
    }
    obterPorId(id){
        return http.get(`/vendedor/ObterId/${id}`);
    }
    obterVendedorNome(nome){
        return http.get(`/vendedor/ConsultarPorNome/${nome}`);
    }
    async deletar(id){
        return await http.delete(`/vendedor/${id}`);
    }
}
export default new VendedorDataService();