using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.Helpers
{
    public sealed class FileHelper
    {
        private readonly ReaderWriterLockSlim cacheLock = new();

        public BlockChain Load()
        {
            cacheLock.EnterReadLock();

            BlockChain bc = new();

            if (File.Exists(Constants.DataStoreFilePath))
            {
                string jsonString = File.ReadAllText(Constants.DataStoreFilePath);
                bc = JsonSerializer.Deserialize<BlockChain>(jsonString);
            }

            cacheLock.ExitReadLock();

            return bc;
        }

        public void Persist(BlockChain chain)
        {
            cacheLock.EnterWriteLock();

            try
            {
                string jsonString = JsonSerializer.Serialize(chain);
                Console.WriteLine(jsonString);
                File.WriteAllText(Constants.DataStoreFilePath, jsonString);
            }
            catch
            {

            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }
    }
}