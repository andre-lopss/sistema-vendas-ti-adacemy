import { HttpProxy } from "vite";
import htttp from "../htttp-common";

class VendedordataService{
    listar(){
        return HttpProxy.get('/vendedor/listar')
    }
}
export default new VendedordataService();