# ITHS_Backend_C_Lab_1

A simple C# Web Rest API - Animals

Joakim Eberholst only

## Requests
* GET /animals Lista samtliga djur.

_Get all_
![image info](./screenshots/GET_ALL.png)

______________

#### GET /animals/{id} Returnera ett djur beroende på vilket id som skickas in.

_Get uid 1_
![image info](./screenshots/GET_ONE.png)
_Get uid 3_
![image info](./screenshots/GET_THREE.png)

______________

#### ~~PUT~~ PATCH/animals/{id} Uppdatera namnet på en djur med rätt id

_Patch 6_
![image info](./screenshots/PATCH_SIX.png)
_Get all_
![image info](./screenshots/PATCH_SIX_THEN_GET_ALL.png)

______________

#### POST /animals Skapar ett nytt djur
_Post new_
![image info](./screenshots/POST_NEW.png)
_Get all_
![image info](./screenshots/POST_NEW_THEN_GET_ALL.png)

______________

#### DELETE /animals/{id} Radera ett djur beroende på vilket id som skickas in.

![image info](./screenshots/DELETE_FIVE.png)
_Get all_
![image info](./screenshots/DELETE_FIVE_THEN_GET_ALL.png)

______________




