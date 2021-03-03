﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
   public float velocidade = 5;
   private Vector3 direcao;
   private GameManager gm;
    // Start is called before the first frame update
   void Start()
   {
       float dirX = Random.Range(-5.0f, 5.0f);
       float dirY = Random.Range(2.0f, 5.0f);

       direcao = new Vector3(dirX, dirY).normalized;

       gm = GameManager.GetInstance();
   }

   // Update is called once per frame
   void Update()
   {
       if (gm.gameState == GameManager.GameState.START)
       {
            Init();
       }
       if (gm.gameState != GameManager.GameState.GAME &
            gm.gameState != GameManager.GameState.RESUME) return;


       transform.position += direcao * Time.deltaTime * velocidade;

       Vector2 posicaoVP = Camera.main.WorldToViewportPoint(transform.position);

       if(posicaoVP.x < 0 || posicaoVP.x > 1)
       {
           direcao = new Vector3(-direcao.x, direcao.y);
       }
       if(posicaoVP.y > 1)
       {
           direcao = new Vector3(direcao.x, -direcao.y);
       }
       if(posicaoVP.y < 0)
       {
           Reset();
       }
    }

   private void Reset()
   {
       Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
       transform.position = playerPosition + new Vector3(0, 0.5f, 0);

       float dirX = Random.Range(-5.0f, 5.0f);
       float dirY = Random.Range(2.0f, 5.0f);

       direcao = new Vector3(dirX, dirY).normalized;
       gm.vidas--;
       SoundManagerScript.PlaySound("death");
       if(gm.vidas < 0)
       {
           gm.ChangeState(GameManager.GameState.ENDGAME);
       }
   }
   private void Init()
   {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(2.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;
        gm.ChangeState(GameManager.GameState.GAME);
    }

   private void OnTriggerEnter2D(Collider2D col)
   {
       if(col.gameObject.CompareTag("Player"))
        {
            SoundManagerScript.PlaySound("slam");

            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;
        }
        else if(col.gameObject.CompareTag("Tijolo"))
        {
            SoundManagerScript.PlaySound("hit");

            direcao = new Vector3(direcao.x, -direcao.y);
        }
   }
}