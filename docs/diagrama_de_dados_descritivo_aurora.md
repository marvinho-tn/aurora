# Diagrama Descritivo de Dados

## 1. **Coleção "Categorias"**

- **_id**: Identificador único da categoria.
- **nome**: Nome da categoria.

### Relacionamentos

- Tem como dependentes as **Categorias Descritivas** e as **Categorias Valoradas**

## 2. **Coleção "Categorias Descricritivas"**

- **_id_da_categoria**: Essa é uma coleção que recebe dados complementares. O seu identificador é uma extensão do __id_ de uma **Categoria**.
- **descrição**: Descrição da categoria.

### Relacionamentos

- Depende das **Caterias** (Base) paea existir

## 3. **Coleção "Categorias Valoradas"**

- **_id_da_categoria**: Essa é uma coleção que recebe dados complementares. O seu identificador é uma extensão do __id_ de uma **Categoria**.
- **valor**: Valor da categoria.

### Relacionamentos

- Depende das **Caterias** (Base) paea existir

## 4. **Coleção "Hierarquia de Categorias"**

- **_id_da_categoria**: Identificador da categoria.
- **_id_da_subcategoria**: Identificador da subcategoria.

### Relacionamentos

- Diz respeito ao fato de que as **Categorias** podem ter subcategorias e serem subcaregorias.

## 5. **Coleção "Estrutura Linguística"**

- **_id_da_memoria**: Identificador da memória que contem o discurso.
- **_id_da_categoria**: Identificador da categoria reconhecida no discurso.

## 6. **Coleção "Memórias"**

- **_id**: Identificador único da memória.
- **discurso**: Texto recebido ou enviado para que a comunicação seja feita.

### Relacionamentos

- Se comunica com as **Categorias** para preencher os discursos.

## 7. **Coleção "Basilar"**

- **_id_do_registro**: Essa é uma coleção que implanta os dados complementares. O seu identificador é uma extensão das coleções
- **data_de_criacao**: Data em que o registro foi motificado na coleção.
- **data_de_modificação**: Data em que o registro foi criado na coleção.
- **tipo_de_modificação**: Tipo de modificação que foi feita no registro.

### Relacionamentos

- Se comunica com as colecoes para extender os seus valores com informações necessarias a comprremsao de auditoria do codigo