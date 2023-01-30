<template>
    <h3 class="text-center">LISTAGEM DE VENDEDORES</h3>

    <div class="container col-8">
        <hr />
        <table class="table table-striped">
            <thead class="bg-primary thead-dark">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Nome</th>
                    <th scope="col">Login</th>
                    <th scope="col" class="text-center">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(vendedor, index) in vendedores" :key="index">
                    <td>{{ vendedor.id }}</td>
                    <td>{{ vendedor.nome }}</td>
                    <td>{{ vendedor.login }}</td>
                    <td class="d-flex justify-content-between">
                        <button class="btn btn-success" @click="editarVendedor(vendedor.id)">Editar</button>
                        <button class="btn btn-danger" @click="excluirVendedor(vendedor)">Excluir</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>

import VendedorDataService from '../../services/VendedorDataService';
export default {
    data() {
        return {
            vendedores: []
        }
    },
    methods: {
        obterVendedores() 
        {
            VendedorDataService.listar()
                .then(response => {
                    this.vendedores = response.data;
                });
        }, 
        editarVendedor(id){
            this.$router.push('/vendedor/' + id);
        },
        async excluirVendedor(vendedor){
            if(confirm(`Tem certeza que deseja excluir o vendedor ${vendedor.nome}?`)){
                await VendedorDataService.deletar(vendedor.id);
                this.obterVendedores();
            }
        }
    },
    mounted(){
        this.obterVendedores();
    }
}
</script>