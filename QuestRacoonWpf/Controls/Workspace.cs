using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf
{
    public class Workspace : DragCanvas
    {
        public void AddBlock(FlowBlock block)
        {
            Children.Add(block);
            SetTop(block, block.Top);
            SetLeft(block, block.Left);
        }

        public FlowBlock GetBlock(string link)
        {
            foreach (var child in Children)
            {
                var block = child as FlowBlock;
                if (block != null && block.Header == link)
                    return block;
            }
            return null;
        }

        public List<FlowBlock> GetBlocks()
        {
            var result = new List<FlowBlock>();
            foreach (var child in Children)
            {
                if (child is FlowBlock)
                    result.Add(child as FlowBlock);
            }
            return result;
        }
    }
}
