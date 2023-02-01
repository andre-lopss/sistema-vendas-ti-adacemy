<template>
    <h3 class="text-center" style="margin-top: 10px;">CADASTRAR SERVIÇO</h3>

    <hr />

    <div class="container col-4">
        <div>
            <label class="form-label">Nome</label>
            <input type="text" required v-model="servico.nome" class="form-control" placeholder="Nome">
        </div>

        <div class="form-group">
            <label for="descricaoServico">Descrição do serviço:</label>
            <textarea class="form-control" v-model="servico.descricao" rows="5"></textarea>
        </div>
        <button class="btn btn-success" @click="cadastrarServico" style="margin-top: 4%">Cadastrar</button>
    </div>
</template>

<script>
import ServicoDataService from '../../services/ServicoDataService';

export default {
    data() {
        return {
            servico: {
                nome: '',
                descricao: ''
            }
        }
    },
    methods: {
        cadastrarServico() {
            var data = {
                nome: this.servico.nome,
                descricao: this.servico.descricao,
            };
            ServicoDataService.cadastrar(data).then(() => {
                this.$router.push('listar');
            });
        }
    }
}
</script>