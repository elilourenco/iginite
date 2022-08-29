import styles from './Comment.module.css';
import {ThumbsUp } from 'phosphor-react';
import {Trash } from 'phosphor-react';
import { Avatar } from './Avatar';
import { useState } from 'react';


export function Comment({content,onDeleteComment}){
 
    const [likeCount,setLikeCount]= useState(0);
    function handleDeleteComment(){
        console.log('deletar');
        onDeleteComment(content);
    }
    function handleLikeComment(){
       setLikeCount((state)=>{
        return state + 1;
       });

        
       
    }
    return(
        <div className={styles.comment}>
            
            <Avatar hasBorder={false} src="https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTV8fHByb2ZpbGV8ZW58MHx8MHx8&w=500&q=50"/>
            
            <div className={styles.commentBox}>
                <div className={styles.commentContent}>
                    <header>
                        <div className={styles.authorAndTime}>
                            <strong>Elizandra Lourenço</strong>
                            <time title="11 de Maio ás 08:13h" dateTime="2022-05-11 08:13:30">Cerca de 1 hora atrás</time>
                                    
                        </div>  

                        <button onClick={handleDeleteComment} title="Deletar comentário">
                        <Trash  size={24} />
                        </button>
                    </header>
                    <p>{content}</p>
                </div>
                <footer>
                    <button onClick={handleLikeComment}>
                       <ThumbsUp /> <span>
                        Aplaudir <strong>{likeCount}</strong></span>
                    </button>
                </footer>
            
           
            </div>
            
        
        </div>
    )
}