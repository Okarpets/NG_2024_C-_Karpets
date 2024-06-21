using System;

namespace task_2._1;

public class SHA2
{
    private static uint[] K = new uint[]
    {
        0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
        0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
        0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
        0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
        0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
        0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
        0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
    };

    private static uint[] H0 = new uint[]
    {
        0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a,
        0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19
    };

    public static byte[] GetHash(byte[] Input)
    {
        byte[] PaddedInput = PadMessage(Input);
        uint[] Hash = (uint[])H0.Clone();

        for (int Index = 0; Index < PaddedInput.Length; Index += 64)
        {
            ProcessChunk(PaddedInput, Index, Hash);
        }
        byte[] Result = new byte[32];
        for (int Index = 0; Index < Hash.Length; Index++)
        {
            Array.Copy(BitConverter.GetBytes(Hash[Index]), 0, Result, Index * 4, 4);
        }

        return Result;
    }

    private static byte[] PadMessage(byte[] Input)
    {
        int OriginalLength = Input.Length;
        byte[] BitLengthBytes = BitConverter.GetBytes(OriginalLength * 8L);
        int PaddingLength = (OriginalLength % 64 < 56) ? 56 - (OriginalLength % 64) : 120 - (OriginalLength % 64);
        byte[] Padded = new byte[OriginalLength + PaddingLength + 8];

        Array.Copy(Input, Padded, OriginalLength);
        Padded[OriginalLength] = 0x80;
        for (int Index = 1; Index < PaddingLength; Index++)
        {
            Padded[OriginalLength + Index] = 0x00;
        }
        Array.Reverse(BitLengthBytes);
        Array.Copy(BitLengthBytes, 0, Padded, OriginalLength + PaddingLength, 8);
        return Padded;
    }

    private static void ProcessChunk(byte[] Chunk, int Offset, uint[] Hash)
    {
        uint[] w = new uint[64];

        for (int Index = 0; Index < 16; Index++)
        {
            w[Index] = BitConverter.ToUInt32(Chunk, Offset + (Index * 4));
            w[Index] = BitConverter.IsLittleEndian ? ReverseBytes(w[Index]) : w[Index];
        }
        for (int Index = 16; Index < 64; Index++)
        {
            uint s0 = RotateRight(w[Index - 15], 7) ^ RotateRight(w[Index - 15], 18) ^ (w[Index - 15] >> 3);
            uint s1 = RotateRight(w[Index - 2], 17) ^ RotateRight(w[Index - 2], 19) ^ (w[Index - 2] >> 10);
            w[Index] = w[Index - 16] + s0 + w[Index - 7] + s1;
        }

        uint a = Hash[0];
        uint b = Hash[1];
        uint c = Hash[2];
        uint d = Hash[3];
        uint e = Hash[4];
        uint f = Hash[5];
        uint g = Hash[6];
        uint h = Hash[7];

        for (int Index = 0; Index < 64; Index++)
        {
            uint S1 = RotateRight(e, 6) ^ RotateRight(e, 11) ^ RotateRight(e, 25);
            uint ch = (e & f) ^ (~e & g);
            uint temp1 = h + S1 + ch + K[Index] + w[Index];
            uint S0 = RotateRight(a, 2) ^ RotateRight(a, 13) ^ RotateRight(a, 22);
            uint maj = (a & b) ^ (a & c) ^ (b & c);
            uint temp2 = S0 + maj;

            h = g;
            g = f;
            f = e;
            e = d + temp1;
            d = c;
            c = b;
            b = a;
            a = temp1 + temp2;
        }

        Hash[0] += a;
        Hash[1] += b;
        Hash[2] += c;
        Hash[3] += d;
        Hash[4] += e;
        Hash[5] += f;
        Hash[6] += g;
        Hash[7] += h;
    }

    public static byte[] Decode(byte[] Hash)
    {
        uint[] DecodedHash = new uint[Hash.Length / 4];

        for (int i = 0; i < DecodedHash.Length; i++)
        {
            DecodedHash[i] = BitConverter.ToUInt32(Hash, i * 4);
        }

        uint[] WorkingVars = (uint[])H0.Clone();

        for (int GlobalIndex = 0; GlobalIndex < DecodedHash.Length / 8; GlobalIndex++)
        {
            uint[] Global = new uint[8];
            Array.Copy(DecodedHash, GlobalIndex * 8, Global, 0, 8);
            uint a = WorkingVars[0];
            uint b = WorkingVars[1];
            uint c = WorkingVars[2];
            uint d = WorkingVars[3];
            uint e = WorkingVars[4];
            uint f = WorkingVars[5];
            uint g = WorkingVars[6];
            uint h = WorkingVars[7];

            for (int Index = 63; Index >= 0; Index--)
            {
                uint S1 = RotateRight(e, 6) ^ RotateRight(e, 11) ^ RotateRight(e, 25);
                uint ch = (e & f) ^ (~e & g);
                uint temp1 = h - S1 - ch - K[Index] - Global[Index % 8];

                uint S0 = RotateRight(a, 2) ^ RotateRight(a, 13) ^ RotateRight(a, 22);
                uint maj = (a & b) ^ (a & c) ^ (b & c);
                uint temp2 = S0 + maj;

                h = g;
                g = f;
                f = e;
                e = d - temp1;
                d = c;
                c = b;
                b = a;
                a = temp1 - temp2;
            }

            WorkingVars[0] -= a;
            WorkingVars[1] -= b;
            WorkingVars[2] -= c;
            WorkingVars[3] -= d;
            WorkingVars[4] -= e;
            WorkingVars[5] -= f;
            WorkingVars[6] -= g;
            WorkingVars[7] -= h;
        }

        byte[] DecodedInput = new byte[WorkingVars.Length * 4];
        for (int Index = 0; Index < WorkingVars.Length; Index++)
        {
            byte[] TempBytes = BitConverter.GetBytes(WorkingVars[Index]);
            Array.Copy(TempBytes, 0, DecodedInput, Index * 4, 4);
        }

        return DecodedInput;
    }

    private static uint RotateRight(uint x, int n)
    {
        return (x >> n) | (x << (32 - n));
    }

    private static uint ReverseBytes(uint x)
    {
        return ((x & 0x000000ff) << 24) | ((x & 0x0000ff00) << 8) | ((x & 0x00ff0000) >> 8) | ((x & 0xff000000) >> 24);
    }
}