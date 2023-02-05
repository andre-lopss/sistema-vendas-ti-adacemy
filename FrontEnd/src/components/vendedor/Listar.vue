<template>
    <h3 class="text-center" style="margin-top: 10px;">LISTAGEM DE VENDEDORES</h3>
    <hr />
    <div class="container col-5">
        <router-link class="btn btn-success" to="/vendedor/cadastrar" style="margin-bottom: 10px;">Adicionar Vendedor</router-link>
        <div class="row">
            <div class="col-6">
                <div class="input-group mb-3">
                    <input type="text" class="form-control" placeholder="Encontrar por Nome" v-model="vendedores.nome">
                    <button class="btn btn-outline-secondary" type="button"
                        @click="obterVendedorNome(vendedores.nome)">Pesquisar</button>
                </div>
            </div>
            <div class="col-6">
                <div class="input-group mb-3">
                    <input type="text" class="form-control" placeholder="Encontrar por Id" v-model="vendedores.id">
                    <button class="btn btn-outline-secondary" type="button"
                        @click="obterVendedorId(vendedores.id)">Pesquisar</button>
                </div>
            </div>
        </div>
        <p v-if="vendedores.length === 0" class="text-center">
            Não foi encontado nenhum Vendedor com esse nome.
        </p>
        <table class="table table-striped" v-else>
            <thead class="bg-dark rounded fonteColor">
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
                            <button class="btn btn-secondary" @click="editarVendedor(vendedor.id)">Editar</button>
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
        obterVendedorNome(nome) {
            VendedorDataService.obterVendedorNome(nome).then(response => this.vendedores = response.data)
        },
        obterVendedorId(id) {
            this.$router.push('/vendedor/obterId/' + id);
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