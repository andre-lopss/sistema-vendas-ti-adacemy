<template>
    <h3 class="text-center" style="margin-top: 10px;">LISTAGEM DE CLIENTES</h3>

    <hr />

    <div class="container col-4">
        <router-link class="btn btn-success" to="/cliente/cadastrar" style="margin-bottom: 10px;">Adicionar
            Cliente</router-link>

        <table class="table table-striped">
            <thead class="bg-dark thead-dark fonteColor">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Nome</th>
                    <th scope="col">Login</th>
                    <th scope="col" class="text-center">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(cliente, index) in clientes" :key="index">
                    <th>{{ cliente.id }}</th>
                    <td>{{ cliente.nome }}</td>
                    <td>{{ cliente.login }}</td>
                    <td>
                        <div class="btn-group btn-group-toggle container" data-toggle="buttons">
                            <button class="btn btn-secondary" @click="editarCliente(cliente.id)">Editar</button>
                            <button class="btn btn-danger" @click="excluirCliente(cliente)">Excluir</button>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>

import ClienteDataService from '../../services/ClienteDataService';
export default {
    data() {
        return {
            clientes: []
        }
    },
    methods: {
        obterClientes() {
            ClienteDataService.listar()
                .then(response => {
                    this.clientes = response.data;
                });
        },
        editarCliente(id) {
            this.$router.push('/cliente/' + id);
        },
        async excluirCliente(cliente) {
            if (confirm(`Tem certeza que deseja excluir o cliente ${cliente.nome}?`)) {
                await ClienteDataService.deletar(cliente.id);
                this.obterClientes();
            }
        }
    },
    mounted() {
        this.obterClientes();
    }
}
</script>