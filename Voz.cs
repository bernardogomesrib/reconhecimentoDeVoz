﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace reconhecimentoDeVoz {


    public class Voz {
        private System.Windows.Forms.TextBox texto;
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();//new System.Globalization.CultureInfo("pt-BR")

        public Voz(System.Windows.Forms.TextBox texto) {
            this.texto = texto;

            Choices comandos = new Choices();
            String[] strComandos = new String[] { "um", "dois", "tres" };
            comandos.Add(strComandos);
            GrammarBuilder gCria = new GrammarBuilder();
            gCria.Append(comandos);
            Grammar gramatica = new Grammar(gCria);
            rec.LoadGrammarAsync(gramatica);
            
            rec.SetInputToDefaultAudioDevice();
            rec.SpeechRecognized += Rec_SpeechRecognized;
        }


        private void Rec_SpeechRecognized(Object bj, SpeechRecognizedEventArgs e) {
            this.texto.Text = e.Result.Text;
        }

        public void ouvir() {
            rec.RecognizeAsync(RecognizeMode.Multiple);
        }
        public void parar() {
            rec.RecognizeAsyncStop();
        }
    }

}
