<template>
    <h3 class="text-center" style="margin-top: 10px;">LISTAGEM DE SERVIÇOS</h3>
    <hr />
    <div class="container col-6">
        <router-link class="btn btn-success" to="/servico/cadastrar" style="margin-bottom: 10px;">Adicionar
            Serviço</router-link>

        <div class="row">
            <div class="col-6">
                <div class="input-group mb-3">
                    <input type="text" class="form-control" placeholder="Encontrar por Nome"
                        v-model="servicos.nome">
                    <button class="btn btn-outline-secondary" type="button"
                        @click="obterServicoNome(servicos.nome)">Pesquisar</button>
                </div>
            </div>
            <div class="col-6">
                <div class="input-group mb-3">
                    <input type="text" class="form-control" placeholder="Encontrar por Id" v-model="servicos.id">
                    <button class="btn btn-outline-secondary" type="button"
                        @click="obterServicoId(servicos.id)">Pesquisar</button>
                </div>
            </div>
        </div>
        <p v-if="servicos.length === 0" class="text-center">
            Não foi encontado nenhum Serviço com esse nome.
        </p>
        <table class="table table-striped" v-else>
            <thead class="bg-dark thead-dark fonteColor">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Nome</th>
                    <th scope="col">Descrição</th>
                    <th scope="col" class="text-center">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(servico, index) in servicos" :key="index">
                    <th>{{ servico.id }}</th>
                    <td>{{ servico.nome }}</td>
                    <td>{{ servico.descricao }}</td>
                    <td>
                        <div class="btn-group btn-group-toggle container" data-toggle="buttons">
                            <button class="btn btn-secondary" @click="editarServico(servico.id)">Editar</button>
                            <button class="btn btn-danger" @click="excluirServico(servico)">Excluir</button>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>

import ServicoDataService from '../../services/ServicoDataService';

export default {
    data() {
        return {
            servicos: []
        }
    },
    methods: {
        obterServicos() {
            ServicoDataService.listar().then(response => {
                this.servicos = response.data;
            });
        },
        obterServicoNome(nome) {
            ServicoDataService.obterServicoNome(nome).then(response => this.servicos = response.data)
        },
        obterServicoId(id) {
            this.$router.push('/servico/obterId/' + id);
        },
        editarServico(id) {
            this.$router.push('/servico/' + id);
        },
        async excluirServico(servico) {
            if (confirm(`Tem certeza que deseja excluir o serviço ${servico.nome}?`)) {
                await ServicoDataService.deletar(servico.id);
                this.obterServicos();
            }
        }
    },
    mounted() {
        this.obterServicos();
    }
}
</script>