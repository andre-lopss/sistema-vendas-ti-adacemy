<template>
    <h3>Listagem de vendedores</h3>

    <div class="col-8">
        <hr />
        <table class="table table.striped">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Nome</th>
                    <th scope="col">Login</th>
                    <th scope="col">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(vendedor, index) in vendedores" :key="index">
                    <td>{{ vendedor.id }}</td>
                    <td>{{ vendedor.nome }}</td>
                    <td>{{ vendedor.login }}</td>
                    <td>
                        <button class="btn btn-success">Excluir</button>
                        <button class="btn btn-danger">Excluir</button>
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
        return 
        {
            vendedores: []
        }
    },
    methods: {
        obterVendedores() 
        {
            VendedorDataService.listar()
                .then(response => 
                {
                    this.vendedores = response.data;
                });
        }
    },
    mounted(){
        this.obterVendedores();
    }
}
</script>