export interface Categoria {
  id: string;
  descricao: string;
  finalidade: number;
}

export enum Finalidade {
  Despesa = 1,
  Receita,
  Ambas
}