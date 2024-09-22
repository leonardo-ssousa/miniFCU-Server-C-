# miniFCU C# Server

![Frame 76](https://github.com/user-attachments/assets/fdcda4e1-97c4-4075-8aa4-997e4b7d95a7)

- Linguagem: C#
- Formato de dados: JSON
- Ambiente: Local
- Objetivo: Intermediar comunicação entre Windows e dispositivo físico (miniFCU) via rede local

<br>
<br>

### ✏️ A Fazer:

- [ ] Alterar retorno da rota de lista de grupos, deverá trazer como chave e valor ("testeGroup": "Grupo de Teste")
- [ ] Criar rota para alterar o valor de Encrease (Entender se fica no server ou no FCU)
- [ ] Integracao com a Api do Flight Simulator

### ☑️ Feito:
✅ Altera rota de apps salvos para trazer apenas os apps abertos.
✅ Criar rota que traga a lista de shortcuts salvos <br>
✅ Relacionar botoes que podem ser ultilizados como atalhos <br>
✅ Criar rota para acionamento dos botões de atalho <br>
✅ Criar um grupo de atalho como Default <br>
✅ Repensar forma de listar os grupos de atalhos aberto <br>
✅ Acesso aos programas em aberto no win <br>
✅ Acesso aos programas salvos <br>
✅ Rota para volume de app especifico <br>
✅ Criar rota para cadastro dos app a serem salvos <br>
✅ Criar rota para cadastro de novos atalhos <br>
✅ Arrumar arquivo de AppConfig.cfg <br>
✅ Criar rota para deletar grupo de atalhos <br>
✅ Adicionar status e tipo dos leds dos botoes nos grupos de atalho <br>

----------------------------

# Volume Mixer

 ### **GET** Saved process list
 Obtem a lista de Apps salvos abertos no windows
 
 ```
 http://localhost:8085/savedprocesslist
 ```
<br>

### **GET** Open process list
 Obtem a lista de Apps abertos no windows além dos salvos
 
 ```
 http://localhost:8085/openprocesslist 
 ```
<br>

### **PUT** Set volume
 Altera o volume de um app especifico, necessário o PID
 
 ```
 http://localhost:8085/setvolume?PID=6520&vol=80
 ```
|   Param   |  Type  |
|-----------|--------|
|    pid    |  int   |
|    vol    |  int   |

<br>

### **GET** Get volume
 Obtém o volume de um app especifico, necessário o PID
 
 ```
 http://localhost:8085/getvolume?PID=6520
 ```
|   Param   |  Type  |
|-----------|--------|
|    pid    |  int   |

<br>

### **GET** Get time
 Retorna a hora atual do sistema
 
 ```
 http://localhost:8085/gettime 
 ```
<br>

### **PUT** Volume up
 Altera o volume de um app especifico em **mais** 5%, necessário o PID
 
 ```
 http://localhost:8085/volumeup?PID=6520
 ```
|   Param   |  Type  |
|-----------|--------|
|    pid    |  int   |

<br>

### **PUT** Volume down
 Altera o volume de um app especifico em **menos** 5%, necessário o PID
 
 ```
 http://localhost:8085/volumedown?PID=6520
 ```
|   Param   |  Type  |
|-----------|--------|
|    pid    |  int   |

<br>

### **POST** Save new app
 Salva um novo app a lista
 
 ```
 http://localhost:8085/savenewapp?processname=chrome&friendlyname=Googgle+Chrome
 ```
|     Param    |  Type  |
|--------------|--------|
| processname  | string |
| friendlyname | string |

<br>


# Shortcuts Groups

 ### **POST** Create Shortcut Group 
 Cria um novo grupo de atalhos
 
 
 ```
 http://localhost:8085/getshortcutgroup?groupname=Exemple+group
 ```
 
 |   Param   |  Type  |
 |-----------|--------|
 | groupname | string |

<br>


### **GET** Read a shortcut group
Retorna um grupo de atalhos especifico

```
http://localhost:8085/getshortcutgroup?groupname=Exemple+group
```

|   Param   |  Type  |
|-----------|--------|
| groupname | string |

<br>

### **GET** Get shortcuts groups list
Obtem a lsita de atalhos disponiveis.

```
http://localhost:8085/getshortcutgroups
```

<br>

### **PUT** Update shortcut group buttons
Atualiza um botão especifico

```
http://localhost:8085/setshortcutbutton?groupname=Exemple+group&buttonname=hdr&keytopress=A
```

|   Param    |  Type  |
|------------|--------|
| groupname  | string |
| buttonname | string |
| keytopress | string |

<br>

### **PUT** Update shortcut group buttons mode
Atualiza o modo de um botão especifico

```
http://localhost:8085/setshortcutbuttonmode?groupname=Exemple+group&buttonname=ap&istoggle=true
```

|   Param    |  Type   |
|------------|---------|
| groupname  | string  |
| buttonname | string  |
|  istoggle  | boolean |

<br>

### **DELETE** Delete shortcut group
Deleta um grupo de atalhos especifico

```
http://localhost:8085/deleteshortcutgroup?groupname=Exemple+group
```

|   Param    |  Type   |
|------------|---------|
| groupname  | string  |

<br>

### **GET** Buttons list
Retorna lista de botões que podem ser usados como atalho.

```
http://localhost:8085/buttonslist
```


<br>

### **POST** Press key
Pressiona uma tecla

```
http://localhost:8085/pressbutton?keytopress=NUMLOCK
```

|    Param    |  Type   |
|-------------|---------|
| pressbutton | string  |
| keytopress  | string  |

<br>
