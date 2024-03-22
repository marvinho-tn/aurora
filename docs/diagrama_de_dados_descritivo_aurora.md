# Diagrama Descritivo de Dados

1. **Coleção "Categorias"**:
   - **_id**: Identificador único da categoria  
   - **nome**: Nome da categoria

2. **Coleção "Categorias Descricritivas"**:
   - **_id_da_categoria**: Identificador único da categoria
   - **descrição**: Descrição da categoria

3. **Coleção "Categorias Valoradas"**:
   - **_id_da_categoria**: Identificador único da categoria
   - **valor**: Valor da categoria

4. **Coleção "Hierarquia de Categorias"**:
   - **_id**: Identificador único da informação
   - **discurso**: Texto recebido ou enviado para que a comunicação seja feita

5. **Coleção "Memórias"**:
   - **_id**: Identificador único da informação
   - **discurso**: Texto recebido ou enviado para que a comunicação seja feita

6. **Coleção "Memórias"**:
   - **_id**: Identificador único da informação
   - **discurso**: Texto recebido ou enviado para que a comunicação seja feita

7. **Coleção "Basilar"**:
   - **_id_do_registro**: Identificador único da de todos os registros de coleções principais.
   - **data_de_criacao**: Data em que o registro foi motificado na coleção.
   - **data_de_modificação**: Dataa em que o registro foi criado na coleção.
   - **tipo_de_modificação**: Tipo de modificação que foi feita no registro.
   - **_id_do_modificador**: Identificador do modificador do registro.
   - **_id_do_criador**: Identificador do criador do registro.
