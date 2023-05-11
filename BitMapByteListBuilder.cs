class BitMapByteListBuilder {
    private List<byte> _bytes = new List<byte>();
    private int _count = 0;
    private int _numBitsInCurrentByte => _count & 0x7; //_count % 8
    private int _currByteInd => _count >> 3; //_count / 8
    

    public void Append(bool bit){
        if (_currByteInd == _bytes.Count){
            AddNewByte();
        }
        byte mask = (byte)((bit ? 1 : 0) << _numBitsInCurrentByte);
        _bytes[_currByteInd] |= mask;
        _count++;
    }

    public void PadCurrentByte(){
        if (_numBitsInCurrentByte == 0){
            return;
        }
        AddNewByte();
        _count += 8 - _numBitsInCurrentByte;
    }

    private void AddNewByte(){
        _bytes.Add(0);
    }

    public List<Byte> ToByteList(){
        return new List<byte>(_bytes);
    }
}