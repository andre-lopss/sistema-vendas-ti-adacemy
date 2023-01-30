<template>
    <h3 class="text-center">CADASTRAR SERVIÇO</h3>

    <div class="form" style="padding: 1%;">
        <div class="container col-8">
            <div>
                <label class="form-label">Nome</label>
                <input type="text" required v-model="servico.nome" class="form-control" placeholder="Nome">
            </div>
            <div class="form-group">
                <label for="descricaoServico">Descrição do serviço:</label>
                <textarea class="form-control" v-model="servico.descricao" rows="3"></textarea>
            </div>
            <button class="btn btn-danger" @click="cadastrarServico" style="margin-top: 4%">Cadastrar</button>
        </div>
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
            ServicoDataService.cadastrar(data)
                .then(() => {
                    this.$router.push('listar');
                });

        }
    }
}
</script>