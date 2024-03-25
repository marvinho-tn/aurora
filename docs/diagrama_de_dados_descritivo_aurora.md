# Diagrama Descritivo de Dados

## 1. **Coleção "Categorias"**

- **_id**: Identificador único do objeto.

### 1.1 Relacionamentos

- Tem como dependentes as coleções de **Nome das Categorias**, **Hierarquia das Categorias**, **Valor das Categorias** e os **Significado das Categorias**

## 2. **Coleção "Nome das Categorias"**

- **_id**: Identificador único do objeto.
- **_id_da_categoria**: Esse é justamente o identificador que faz com que o nome seja parte de uma determinada categoria.
- **nome**: Nome da categoria.

### 2.1 Relacionamentos

- Depende de uma **Categoria** para existir
- Um **Nome de Categoria** pode servir a várias **Categoias** diferentes.

## 3. **Coleção "Valor das Categorias"**

- **_id**: Identificador único do objeto.
- **_id_do_nome_da_categoria**: Esse é justamente o identificador que faz com que o valor seja atribuido a um determinado nome mesmo que hajam varias categorias com o mesmo nome.
- **valor**: Valor da categoria.

### 3.1 Relacionamentos

- Depende das **Categorias** (Base) paea existir

## 4. **Coleção "Hierarquia de Categorias"**

- **_id_da_categoria**: Identificador da categoria.
- **_id_da_subcategoria**: Identificador da subcategoria.

### 4.1 Relacionamentos

- Diz respeito ao fato de que as **Categorias** podem ter subcategorias e serem subcaregorias.

## 5. **Coleção "Significado das Categorias"**

- **_id**: Identificador único do objeto.
- **_id_do_nome_da_categoria**: Esse é justamente o identificador que faz com que o significado seja atribuido a um determinado nome mesmo que hajam varias categorias com o mesmo nome.

## 6. **Coleção "Memórias"**

- **_id**: Identificador único da memória.
- **discurso**: Texto recebido ou enviado para que a comunicação seja feita.

### 5.1 Relacionamentos

- Se comunica com as **Categorias** para preencher os discursos.

## 7. **Coleção "Basilar"**

- **_id_do_registro**: Essa é uma coleção que implanta os dados complementares. O seu identificador é uma extensão das coleções
- **data_de_criacao**: Data em que o registro foi motificado na coleção.
- **data_de_modificação**: Data em que o registro foi criado na coleção.
- **tipo_de_modificação**: Tipo de modificação que foi feita no registro.

### 7.1 Relacionamentos

- Se comunica com as colecoes para extender os seus valores com informações necessarias a comprremsao de auditoria do codigo
