import { Avatar } from './Avatar';
import { Comment } from './Comment';
import styles from './Post.module.css';
import {format, formatDistanceToNow} from 'date-fns';
import ptBR from 'date-fns/locale/pt-BR';
import { useState } from 'react';





export function Post({author,publishedAt,content}){
    
    const [comments,setComments]=useState([
       'Post muito bacana, hein!?'
    ])


    const [newCommentText,setNewCommentText]=useState('')
    console.log(newCommentText);
    const publishedDateFormatted= format(publishedAt,"d 'de' LLLL 'ás' de HH:mm 'h'",{
         locale:ptBR,
    })
    const publisheaDateRelativeToNow= formatDistanceToNow(publishedAt,{
        locale:ptBR,
        addSuffix:true,

    })
    function handleCreateNewComment(){
        event.preventDefault()
        

        const newCommentText= event.target.comment.value
    
        setComments([...comments,newCommentText]);
        setNewCommentText('');
    
    }

    function handleNewCommentChange(){
        setNewCommentText(event.target.value);
    }

    function handleNewCommentInvalid(){
        event.target.setCustomValidity('');
    }

    function onDeleteComment(commentToDelete){

        const commentsWithoutDeleteOne= comments.filter(comment=>{
            return comment != commentToDelete;
        })
    setComments(commentsWithoutDeleteOne);
    }

    const isNewCommentEmpty= newCommentText.length ==0;

    return(

        <article className={styles.post}>
            <header>
                <div className={styles.author}>
                    <Avatar  src={author.avatarUrl} />
                    <div className={styles.authorInfo}>
                        <strong> {author.name}</strong>
                        <span>{author.role}</span>

                    </div>
                </div>
                <time title="11 de Maio ás 08:13h" dateTime={publishedAt.toISOString()}>
                    {publisheaDateRelativeToNow}
                </time>
            </header>
            
            <div className={styles.content}>
            {content.map((line)=>{
                if(line.type == 'paragraph'){
                    return <p key={line.content}>{line.content}</p>;

                }else if(line.type =='link'){
                    return <p key={line.content}><a href="#">{line.content}</a></p>;
                }})

            }

            </div>
            
            
            <form onSubmit={handleCreateNewComment} className={styles.commentForm}>
                <strong>Deixe seu feedBack</strong>
                <textarea name="comment" 
                    placeholder="Deixe um comentário"
                    value={newCommentText}
                    onChange={handleNewCommentChange}
                    onInvalid={handleNewCommentInvalid}
                    required >

                </textarea>
                <footer> 
                    <button  type='submit' disabled={isNewCommentEmpty} >Publicar</button>
                </footer>
                
                
            </form>
            
           

            <div className={styles.commentList}>
            {
                comments.map((comment)=>{
                    return  <Comment  key={comment} content={comment} onDeleteComment={onDeleteComment} />
                })}
            

           
            
            </div>

           

        </article>
    )
}