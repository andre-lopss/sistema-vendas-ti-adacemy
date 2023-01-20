import http from "../htttp-common";

class VendedorDataService{
    listar(){
        return http.get('/vendedor/listar')
    }
}
export default new VendedorDataService();