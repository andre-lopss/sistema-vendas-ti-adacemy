<template>
    <h3 class="text-center" style="margin-top: 10px;">LISTAGEM DE VENDEDORES</h3>

    <hr />

    <div class="container col-5">

        <router-link class="btn btn-success" to="/vendedor/cadastrar" style="margin-bottom: 10px;">Cadastrar
            vendedor</router-link>

        <table class="table table-striped">

            <thead class="bg-primary rounded fonteColor">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Nome</th>
                    <th scope="col">Login</th>
                    <th scope="col" class="text-center">Ações</th>
                </tr>
            </thead>

            <tbody>
                <tr v-for="(vendedor, index) in vendedores" :key="index">
                    <th scope="row">{{ vendedor.id }}</th>
                    <td>{{ vendedor.nome }}</td>
                    <td>{{ vendedor.login }}</td>
                    <td>
                        <div class="btn-group btn-group-toggle container" data-toggle="buttons">
                            <button class="btn btn-primary" @click="editarVendedor(vendedor.id)">Editar</button>
                            <button class="btn btn-danger" @click="excluirVendedor(vendedor)">Excluir</button>
                        </div>
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
        obterVendedores() {
            VendedorDataService.listar().then(response => {
                this.vendedores = response.data;
            });
        },
        editarVendedor(id) {
            this.$router.push('/vendedor/' + id);
        },
        async excluirVendedor(vendedor) {
            if (confirm(`Tem certeza que deseja excluir o vendedor ${vendedor.nome}?`)) {
                await VendedorDataService.deletar(vendedor.id);
                this.obterVendedores();
            }
        }
    },
    mounted() {
        this.obterVendedores();
    }
}
</script>