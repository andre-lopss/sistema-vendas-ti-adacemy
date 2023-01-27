import http from "../htttp-common";

class ClienteDataService{
    listar(){
        return http.get('/cliente/listar')
    }
    
    cadastrar(cliente){
        return http.post('/cliente', cliente)
    }
}