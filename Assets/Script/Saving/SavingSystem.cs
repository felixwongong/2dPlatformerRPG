using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace Platformer.Saving
{
    public class SavingSystem : MonoBehaviour
    {
        public void Save(string saveFile)
        {
            string path = getPathFromSaveFile(saveFile);
            print("Saving to " + path);
            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                Transform playerTransform = GetPlayerTransform();
                byte[] bytes = SerializeVector(playerTransform.position);
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        private static Transform GetPlayerTransform()
        {
            return GameObject.FindWithTag("Player").transform;
        }

        public void Load(string loadFile)
        {
            string path = getPathFromSaveFile(loadFile);
            print("Loading from " + getPathFromSaveFile(loadFile));
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                GetPlayerTransform().position = DeserializeVector(buffer);
            }
        }

        private byte[] SerializeVector(Vector3 vector)
        {
            byte[] buffer = new byte[3 * 4];
            BitConverter.GetBytes(vector.x).CopyTo(buffer, 0);
            BitConverter.GetBytes(vector.y).CopyTo(buffer, 4);
            BitConverter.GetBytes(vector.z).CopyTo(buffer, 8);
            return buffer;
        }

        private Vector3 DeserializeVector(byte[] buffer)
        {
            Vector3 vector = new Vector3();
            vector.x = BitConverter.ToSingle(buffer, 0);
            vector.y = BitConverter.ToSingle(buffer, 4);
            vector.z = BitConverter.ToSingle(buffer, 8);
            return vector;
        }

        private string getPathFromSaveFile(string saveFile)
        {
            return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        }
    }
}
